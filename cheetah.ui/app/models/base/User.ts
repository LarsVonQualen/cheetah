module Cheetah.Models {
  export class User extends Base.BaseModelWithStringKey {
    public firstname: string;
    public lastname: string;
    public username: string;
    public password: string; // TODO: Obviously has to go at some point!
    public location: string;
    public birthday: Date;
    public email: string;
    public description: string;
    public teams: Array<Domain.Team>;
    public roles: Array<Domain.Role>;

    constructor(
      firstname: string
      , lastname: string
      , username: string
      , password: string
      , location: string
      , birthday: Date
      , email: string
      , description: string
      ) {
        super();

        this.firstname = firstname;
        this.lastname = lastname;
        this.username = username;
        this.password = password;
        this.location = location;
        this.birthday = birthday;
        this.email = email;
        this.description = description;
      }
  }
}
