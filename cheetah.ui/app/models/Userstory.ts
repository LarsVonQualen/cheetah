module Cheetah.Models {
  export class Userstory extends BaseModelWithStringKey {
    public identiy: number;
    public story: string;
    public risks: string;
    public acceptCriterias: string;
    public feature: Array<Feature>;
    public dependencies: Array<Userstory>;
  }
}
