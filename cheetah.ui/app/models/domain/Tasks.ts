module Cheetah.Models.Domain {
  export class Task extends Base.BaseModelWithStringKey {
    public identity: number;
    public summary: string;
    public description: string;
    public estimate: number;
    public remaining: number;
    public userstory: Userstory;
    public dependencies: Array<Task>;
  }
}
