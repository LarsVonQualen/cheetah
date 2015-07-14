module Cheetah.Models.Domain {
  export class Team extends Base.BaseModelWithStringKey {
    public name: string;
    public description: string;
    public organization: Organization;
    public users: Array<User>;
  }
}
