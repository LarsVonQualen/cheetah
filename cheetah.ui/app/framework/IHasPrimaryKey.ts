module Cheetah.Framework {
  export interface IHasPrimaryKey<TPrimaryKey> {
    getPrimaryKey(): TPrimaryKey;
    setPrimaryKey(value: TPrimaryKey);
  }
}
