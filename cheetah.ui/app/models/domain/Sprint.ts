module Cheetah.Models.Domain {
  export class Sprint extends Base.BaseModelWithStringKey {
    public name: string;
    public goal: string;
    public userstories: Array<Userstory>;
  }
}
