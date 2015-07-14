module Cheetah.Models.Domain {
  export class Feature extends Base.BaseModelWithStringKey {
    public label: string;
    public name: string;
    public description: string;
    public userstories: Array<Userstory>;
  }
}
