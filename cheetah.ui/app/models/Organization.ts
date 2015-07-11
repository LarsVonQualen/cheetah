module Cheetah.Models {
  export class Organization extends BaseModelWithStringKey {
    public name: string;
    public description: string;
    public corporation: Corporation;
  }
}
