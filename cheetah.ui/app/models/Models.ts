module Cheetah.Models {
  export enum TokenType {
    AccessToken = 1,
    RefreshToken = 2
  }

  export class TokenTypeUtility {
    static AccessToken: string = "access";
    static RefreshToken: string = "refresh";

    static ToEnum(type: string): TokenType {
      switch(type) {
        case TokenTypeUtility.AccessToken:
          return TokenType.AccessToken;
        case TokenTypeUtility.RefreshToken:
          return TokenType.RefreshToken;
      }
    }

    static ToString(type: TokenType): string {
      switch(type) {
        case TokenType.AccessToken:
          return TokenTypeUtility.AccessToken;
          case TokenType.RefreshToken:
            return TokenTypeUtility.RefreshToken;
      }
    }
  }

  export class Notification {
    constructor(
      public type: Enums.NotificationType,
      public body: string,
      public title: string = "",
      public lifeCycle: Enums.NotificationLifecycle = Enums.NotificationLifecycle.Transient
    ) {}

    public computedType(): string {
      switch (this.type) {
        case Enums.NotificationType.Success:
          return "success";
        case Enums.NotificationType.Warning:
          return "warning";
        case Enums.NotificationType.Info:
          return "info";
        case Enums.NotificationType.Danger:
          return "danger";
      }
    }
  }

  export class AccessToken extends Framework.BaseModel {
    public Id: number;
    public Type: TokenType;
    public UserId: string;
    public Token: string;
    public Expires: Date;
    public CreatedAt: Date;

    public static map(model: any): AccessToken {
      model = super.normalizeModel(model);
      var mapped = super.map<AccessToken>(model || {});

      mapped.Id = model.Id;
      mapped.Type = TokenTypeUtility.ToEnum(model.Type);
      mapped.UserId = model.UserId;
      mapped.Token = model.Token;
      mapped.Expires = Framework.Utility.ToDate(model.Expires);
      mapped.CreatedAt = Framework.Utility.ToDate(model.CreatedAt);

      return mapped;
    }
  }

  export class UserProfile extends Framework.BaseModel {
    public Id: number;
    public Firstname: string;
    public Lastname: string;
    public DateOfBirth: Date;
    public Location: string;
    public Description: string;

    public static map(model: any): UserProfile {
      model = super.normalizeModel(model);
      var mapped = super.map<UserProfile>(model || {});

      mapped.Id = model.Id;
      mapped.Firstname = model.Firstname;
      mapped.Lastname = model.Lastname;
      mapped.DateOfBirth = Framework.Utility.ToDate(model.DateOfBirth);
      mapped.Location = model.Location;
      mapped.Description = model.Description;

      return mapped;
    }
  }

  export class User extends Framework.BaseModel {
    public Id: number;
    public UserId: string;
    public Username: string;
    public CreatedAt: Date;
    public ClientId: string;
    public Email: string;
    public UserProfileId: number;
    public UserProfile: UserProfile;

    public static map(model: any): User {
      model = super.normalizeModel(model);
      var mapped = super.map<User>(model || {});

      mapped.Id = model.Id;
      mapped.UserId = model.UserId;
      mapped.Username = model.Username;
      mapped.CreatedAt = Framework.Utility.ToDate(model.CreatedAt);
      mapped.ClientId = model.ClientId;
      mapped.Email = model.Email;
      mapped.UserProfileId = model.UserProfileId;
      mapped.UserProfile = UserProfile.map(model.UserProfile);

      return mapped;
    }
  }

  export class UserViewModel extends Framework.BaseModel {
    public Info: User;
    public Password: string;

    public static map(model: any): UserViewModel {
      model = super.normalizeModel(model);
      var mapped = super.map<UserViewModel>(model || {});

      mapped.Info = User.map(model.Info);
      mapped.Password = model.Password;

      return mapped;
    }
  }

  export class RefreshToken extends Framework.BaseModel {
    public Id: number;
    public Type: TokenType;
    public UserId: string;
    public Token: string;
    public CreatedAt: Date;

    public static map(model: any): RefreshToken {
      model = super.normalizeModel(model);
      var mapped = super.map<RefreshToken>(model || {});

      mapped.Id = model.Id;
      mapped.Type = TokenTypeUtility.ToEnum(model.Type);
      mapped.UserId = model.UserId;
      mapped.Token = model.Token;
      mapped.CreatedAt = Framework.Utility.ToDate(model.CreatedAt);

      return mapped;
    }
  }

  export class UserInfoViewModel extends Framework.BaseModel {
    public User: User;
    public RefreshToken: RefreshToken;

    public static map(model: any): UserInfoViewModel {
      model = super.normalizeModel(model);
      var mapped = super.map<UserInfoViewModel>(model || {});

      mapped.User = User.map(model.User);
      mapped.RefreshToken = RefreshToken.map(model.RefreshToken);

      return mapped;
    }
  }

  export class RefreshRequest extends Framework.BaseModel {
    constructor(public ClientId: string, public RefreshToken: RefreshToken) {
      super();
    }

    public static map(model: any): RefreshRequest {
      model = super.normalizeModel(model);
      var mapped  = super.map<RefreshRequest>(model || {});

      mapped.ClientId = model.ClientId;
      mapped.RefreshToken = RefreshToken.map(model.RefreshToken);

      return mapped;
    }
  }

  export class LocalAuthRequest extends Framework.BaseModel {
    constructor(public Username: string, public Password: string) {
      super();
    }

    public static map(model: any): LocalAuthRequest {
      model = super.normalizeModel(model);
      var mapped = super.map<LocalAuthRequest>(model || {});

      mapped.Username = model.Username;
      mapped.Password = model.Password;

      return mapped;
    }
  }

  export class AuthorizationGrant extends Framework.BaseModel {
    public ClientId: string;
    public RefreshToken: RefreshToken;

    public static map(model: any): AuthorizationGrant {
      model = super.normalizeModel(model);
      var mapped = super.map<AuthorizationGrant>(model || {});

      mapped.ClientId = model.ClientId;
      mapped.RefreshToken = RefreshToken.map(model.RefreshToken);

      return mapped;
    }
  }

  export class AuthenticationResponse extends Framework.BaseModel {
    public IsValid: boolean;

    public static map(model: any): AuthenticationResponse {
      model = super.normalizeModel(model);
      var mapped = super.map<AuthenticationResponse>(model || {});

      mapped.IsValid = model.IsValid;

      return mapped;
    }
  }

}
