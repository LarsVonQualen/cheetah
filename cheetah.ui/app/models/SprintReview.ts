module Cheetah.Models {
  export class SprintReview extends BaseModelWithStringKey {
    public review: string;
    public sprint: Sprint;
  }
}
