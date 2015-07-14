module Cheetah.Models.Domain {
  export class Permission extends Base.BaseModelWithStringKey {
    public name: string;
    public description: string;
    public roles: Array<Role>;
  }
}
