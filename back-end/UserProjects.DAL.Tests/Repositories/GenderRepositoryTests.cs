namespace UserProjects.DAL.Test.Repositories
{

   
    [ExcludeFromCodeCoverage]
    public class GenderRepositoryTests : BaseTest<GenderRepository>
    {



        [TestMethod]
        public async Task FindOrInsertGenderByNameAsyncGenderFound()
        {
            var genderName = "Female";
            await ExecuteTestAsync(genderName);
        }

        [TestMethod]
        public async Task FindOrInsertGenderByNameAsyncGenderNotFound()
        {
            var genderName = "Male";
            await ExecuteTestAsync(genderName);
        }

        private async Task ExecuteTestAsync(string genderName)
        {
            await ExecuteFindOrInsertGenderByNameAsync(genderName, async (repository) =>
            {
                if (repository.Get().Any())
                {
                    var genderList = repository.Get();
                    foreach(var gender in genderList)
                    {
                        await repository.DeleteAsync(gender.Id);
                    }
                }
                await repository.AddAsync( new Gender { Name = "Female" });

            }, async (context, response) =>
            {
                Assert.IsNotNull(response, "Result is not success");
                Assert.AreEqual(response.Name, genderName, "Gender Name is not equal");
                await Task.FromResult(Task.CompletedTask);
            });
        }

        private async Task ExecuteFindOrInsertGenderByNameAsync(string genderName, Func<GenderRepository,Task> preAction, Func<GenderRepository, Gender, Task> verificationAction)
        {
            using (var mock = AutoMock.GetStrict())
            {
                var genderRepository = GivenTheSystemUnderTest(mock);

                await preAction(genderRepository);

                var response = await genderRepository.FindOrInsertGenderByNameAsync(genderName);
                await verificationAction(genderRepository, response);
            }
        }

        private static GenderRepository GivenTheSystemUnderTest(AutoMock mock)
        {
            var options = GivenTheFollowingDbOptions();
            var ctx = GivenTheDefaultDbContext(options, mock);

            var optionsParameter = new NamedParameter("dbContext", ctx);
            var sut = mock.Create<GenderRepository>(optionsParameter);
            return sut;
        }

        private static SurealDataContext GivenTheDefaultDbContext(DbContextOptions<SurealDataContext> options, AutoMock mock)
        {
            var iLogger = mock.Mock<ILogger<SurealDataContext>>();
            return new SurealDataContext(options, iLogger.Object);
        }

        private static DbContextOptions<SurealDataContext> GivenTheFollowingDbOptions()
        {
            var options = new DbContextOptionsBuilder<SurealDataContext>()
                    .UseInMemoryDatabase(databaseName: "UnitTestingDB")
                    .Options
                ;
            return options;
        }
    }
}