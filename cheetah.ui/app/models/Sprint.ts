module Cheetah.Models {
  export class Sprint extends BaseModelWithStringKey {
    public name: string;
    public goal: string;
    public userstories: Array<Userstory>;
  }
}
