namespace UserProjects.Common.Results
{
    public static class ResponseCreator
    {
        public static Response  CreateNegativeResponse()
        {
            return CreateResponse(false);
        }

        public static  Response CreateResponse(bool result)
        {
            var response = new Response
            {
                Result = result
            };
            return response;
        }

        public static Response CreatePositiveResponse()
        {
            return CreateResponse(true);
        }

        public static TokenResponse CreatePositiveTokenResponse(string token)
        {
            var response = new TokenResponse
            {
                Token = token,
                Result = true
            };
            return response;
        }

        public static TokenResponse CreateNegativeTokenResponse()
        {
            var response = new TokenResponse
            {
                Result = false
            };
            return response;
        }

        public static ObjectResponse<TObject> CreatePositiveObjectResponse<TObject>(TObject value) where TObject : class
        {
            var response = new ObjectResponse<TObject>
            {
                Object = value,
                Result = true
            };
            return response;
        }

        public static ObjectResponse<TObject> CreateNegativeObjectResponse<TObject>() where TObject : class
        {
            var response = new ObjectResponse<TObject>
            {
                Result = false
            };
            return response;
        }
    }
}
