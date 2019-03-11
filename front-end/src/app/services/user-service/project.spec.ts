import { Project } from './project';

describe('Project', () => {
  it('should create an instance', () => {
    expect(new Project(1,new Date(), new Date(), 1, false)).toBeTruthy();
  });
});
