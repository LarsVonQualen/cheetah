module Cheetah.Models.Domain {
  export class SprintReview extends Base.BaseModelWithStringKey {
    public review: string;
    public sprint: Sprint;
  }
}
