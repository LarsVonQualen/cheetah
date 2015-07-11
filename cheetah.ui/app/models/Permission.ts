module Cheetah.Models {
  export class Permission extends BaseModelWithStringKey {
    public name: string;
    public description: string;
    public roles: Array<Role>;
  }
}
