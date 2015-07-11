module Cheetah.Models {
  export class Metadata extends BaseModelWithStringKey {
    public createdAt: Date = new Date();
    public createdBy: string;
    public lastUpdatedAt: Date;
    public lastUpdatedBy: string;
  }
}
