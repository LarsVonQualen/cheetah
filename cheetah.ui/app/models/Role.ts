module Cheetah.Models {
  export class Role extends BaseModelWithStringKey {
    public name: string;
    public description: string;
    public permissions: Array<Permission>;
  }
}
