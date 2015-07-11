module Cheetah.Models {
  export class SprintRetrospective extends BaseModelWithStringKey {
    public headline: string;
    public keepDoing: Array<SprintRetrospectiveItem>;
    public stopDoing: Array<SprintRetrospectiveItem>;
    public startDoing: Array<SprintRetrospectiveItem>;
    public sprint: Sprint;
  }
}
