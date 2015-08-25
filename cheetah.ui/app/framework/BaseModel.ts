module Cheetah.Framework {
  export class BaseModel {
    public static map<TModel>(obj: any): TModel {
      if (obj === undefined || obj === null)
        throw new Error("Unable to map undefined or null.");

      return <TModel>(Object.create({}));
    }
  }
}
