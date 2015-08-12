module Cheetah.Models.Domain {
  export class Project extends Base.BaseModelWithStringKey {
    public name: string;
    public description: string;
    public label: string;
    public organization: Organization;
    public teams: Array<Team>;
    public users: Array<User>;

    constructor(label: string, name: string, description: string, createdBy: string) {
      super();

      this.label = label;
      this.name = name;
      this.description = description;
      //this.meta.createdBy = new User();
      this.meta.createdBy.username = createdBy;
    }
  }
}
