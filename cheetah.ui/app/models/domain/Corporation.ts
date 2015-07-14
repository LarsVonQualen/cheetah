module Cheetah.Models.Domain {
  export class Corporation extends Base.BaseModelWithStringKey {
    public name: string;
    public description: string;
    public address: Address;
  }
}
