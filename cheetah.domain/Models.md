### Metadata
- createdAt: Date?
- createdBy: User?
- lastUpdatedAt: Date?
- lastUpdatedBy: User?

### BillingAddress
- street: string
- city: string
- zipCode: string
- countryCode: string
- meta: Metadata

### Corporation
- name: string
- description: string
- billingAddress: BillingAddress
- meta: Metadata

### Organization
- name: string
- description: string
- corporation: Corporation
- meta: Metadata

### Permission
- name: string
- description: string
- meta: Metadata
- roles: List Role

### Role
- name: string
- description: string
- meta: Metadata
- permisions: List Permission

### User
- firstname: string
- lastname: string
- username: string
- location: string
- birthday: Date
- email: string
- description: string
- meta: Metadata
- teams: List Team
- roles: List Role

### Team
- name: string
- description: string
- meta: Metadata
- organization: Organization
- users: List User

### Project
- name: string
- description: string
- label: string
- meta: Metadata
- organization: Organization
- teams: List Team
- users: List User

### Feature
- label: string
- name: string
- description: string
- meta: Metadata
- userstories: List Userstory

### Sprint
- name: string
- goal: string
- meta: Metadata
- userstories: List Userstory

### Userstory
- identiy: integer
- story: string
- risks: string
- acceptCriterias: string
- feature: List Feature
- meta: Metadata
- dependencies: List Userstory

### Task
- identiy: integer
- summary: string
- description: string
- estimate: number
- remaining: number
- userstory: Userstory
- meta: Metadata
- dependencies: List Task

### Sprint Retrospective Item
- description: string
- meta: Metadata

### Sprint Retrospective
- headline: string
- keepDoing: List Sprint Retrospective Item
- stopDoing: List Sprint Retrospective Item
- startDoing: List Sprint Retrospective Item
- meta: Metadata
- sprint: Sprint

### Sprint Review
- review: string
- meta: Metadata
- sprint: Sprint
