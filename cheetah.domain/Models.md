# Address
street: string
city: string
zipCode: string
countryCode: string
createdAt: Date
lastUpdatedAt: Date

# Corporation
name: string
description: string
address: Address
createdAt: Date
lastUpdatedAt: Date

# Organization
name: string
description: string
createdAt: Date
createdBy: User
lastUpdatedAt: Date
lastUpdatedBy: User
corporation: Corporation

# Project
name: string
description: string
createdAt: Date
createdBy: User
lastUpdatedAt: Date
lastUpdatedBy: User
organization: Organization
