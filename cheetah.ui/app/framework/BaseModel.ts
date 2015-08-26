module Cheetah.Framework {
  export class BaseModel {
    public static normalizeModel(obj: any): any {
      return obj || {};
    }

    public static map<TModel>(obj: any): TModel {
      if (obj === null) {
        obj = Object.create({});
      }

      return <TModel>(Object.create({}));
    }
  }
}
