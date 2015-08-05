module Cheetah.Models {
  export class Notification {
    constructor(
      public lifecycle: Enums.NotificationLifecycle
      , title: string
      , body: string
    ) {}
  }
}
