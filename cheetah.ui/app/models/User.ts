module Cheetah.Models {
  export class User extends BaseModelWithStringKey {
    public firstname: string;
    public lastname: string;
    public username: string;
    public password: string; // TODO: Obviously has to go at some point!
    public location: string;
    public birthday: Date;
    public email: string;
    public description: string;
    public teams: Array<Team>;
    public roles: Array<Role>;
  }
}
