module Cheetah.Models.Domain {
  export class Role extends Base.BaseModelWithStringKey {
    public name: string;
    public description: string;
    public permissions: Array<Permission>;
  }
}
