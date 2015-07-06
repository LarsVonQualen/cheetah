module Cheetah.Models {
  export class Project extends BaseModelWithStringKey {
    constructor(
      public name: string,
      public description: string,
      public createdAt: Date,
      public createdBy: string
      ) {
      super();
    }
  }
}
