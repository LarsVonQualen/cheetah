module Cheetah.Models.Base {
  export class Metadata {
    public createdAt: Date = new Date();
    public createdBy: User;
    public lastUpdatedAt: Date;
    public lastUpdatedBy: User;
  }
}
