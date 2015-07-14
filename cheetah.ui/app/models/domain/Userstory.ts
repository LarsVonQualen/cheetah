module Cheetah.Models.Domain {
  export class Userstory extends Base.BaseModelWithStringKey {
    public identiy: number;
    public story: string;
    public risks: string;
    public acceptCriterias: string;
    public feature: Array<Feature>;
    public dependencies: Array<Userstory>;
  }
}
