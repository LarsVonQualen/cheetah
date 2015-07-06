module Cheetah.Animations {
  angular.module("cheetah.animations").animation(".cheetah-slide", () => {
    return {
      enter: ($element: JQuery) => $element.slideDown(),
      leave: ($element: JQuery) => $element.slideUp()
    };
  });
}
