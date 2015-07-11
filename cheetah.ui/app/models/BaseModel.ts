module Cheetah.Models {
  export class BaseModel<TPrimaryKey> {
    public Id: TPrimaryKey;
    public meta: Metadata = new Metadata();
  }
}
