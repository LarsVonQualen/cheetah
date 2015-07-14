module Cheetah.Models.Base {
  export class BaseModel<TPrimaryKey> {
    public id: TPrimaryKey;
    public meta: Metadata = new Metadata();
  }
}
