import { User } from './user';

describe('User', () => {

  

  it('should create an instance', () => {
    var user = new User(1,"first", "last");
    expect(user).toBeTruthy();
  });

  it('should get id', () => {
    var user = new User(1,"first", "last");
    expect(user.id).toBe(1);
  });


  it('should get UserName', () => {
    var user = new User(1,"first", "last");
    expect(user.UserName).toBe("first - last");
  });

});
