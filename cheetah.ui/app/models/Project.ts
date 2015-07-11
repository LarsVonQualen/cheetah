module Cheetah.Models {
  export class Project extends BaseModelWithStringKey {
    public name: string;
    public description: string;
    public label: string;
    public organization: Organization;
    public teams: Array<Team>;
    public users: Array<User>;
  }
}
