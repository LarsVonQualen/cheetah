module Cheetah.Models {
  export class Task extends BaseModelWithStringKey {
    public identity: number;
    public summary: string;
    public description: string;
    public estimate: number;
    public remaining: number;
    public userstory: Userstory;
    public dependencies: Array<Task>;
  }
}
