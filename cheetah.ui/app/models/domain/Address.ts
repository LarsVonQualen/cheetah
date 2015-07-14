module Cheetah.Models.Domain {
  export class Address extends Base.BaseModelWithStringKey {
    public street: string;
    public city: string;
    public zipCode: string;
    public countryCode: string;
  }
}
