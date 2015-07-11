module Cheetah.Models {
  export class Corporation extends BaseModelWithStringKey {
    public name: string;
    public description: string;
    public address: Address;
  }
}
