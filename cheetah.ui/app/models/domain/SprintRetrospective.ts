module Cheetah.Models.Domain {
  export class SprintRetrospective extends Base.BaseModelWithStringKey {
    public headline: string;
    public keepDoing: Array<SprintRetrospectiveItem>;
    public stopDoing: Array<SprintRetrospectiveItem>;
    public startDoing: Array<SprintRetrospectiveItem>;
    public sprint: Sprint;
  }
}
