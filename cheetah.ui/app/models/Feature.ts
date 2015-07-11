module Cheetah.Models {
  export class Feature extends BaseModelWithStringKey {
    public label: string;
    public name: string;
    public description: string;
    public userstories: Array<Userstory>;
  }
}
