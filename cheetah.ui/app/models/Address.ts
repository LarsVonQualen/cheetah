module Cheetah.Models {
  export class Address extends BaseModelWithStringKey {
    public street: string;
    public city: string;
    public zipCode: string;
    public countryCode: string;
  }
}
