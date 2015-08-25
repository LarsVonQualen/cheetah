module Cheetah.Framework {
  export class Utility {
    public static ToDate(date: any): Date {
      return angular.isDate(date) ? date : new Date(date);
    }
  }
}
