module Cheetah.Models.Domain {
  export class Organization extends Base.BaseModelWithStringKey {
    public name: string;
    public description: string;
    public corporation: Corporation;
  }
}
