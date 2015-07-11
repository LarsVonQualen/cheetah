module Cheetah.Models {
  export class User extends BaseModelWithStringKey {
    public firstname: string;
    public lastname: string;
    public username: string;
    public location: string;
    public birthday: Date;
    public email: string;
    public description: string;
    public teams: Array<Team>;
    public roles: Array<Role>;
  }
}
