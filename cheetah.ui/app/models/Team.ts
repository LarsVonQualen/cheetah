module Cheetah.Models {
  export class Team extends BaseModelWithStringKey {
    public name: string;
    public description: string;
    public organization: Organization;
    public users: Array<User>;
  }
}
