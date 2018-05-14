export interface UserInfoModel {
    firstName: string;
    lastName: string;
    phoneNumber: string;
}

export interface UpdatePasswordModel {
    oldPassword: string;
    newPassword: string;
    confirmPassword: string;
}

export interface IBook {
    id: string;
    bookId: string;
    title: string;
    author: string;
    country: string;
    language: string;
    genre: string;
    publisher: string;
}

export class UserDemand {
    id: number;

    description: string;

    price: Price;

    bookId: string;

    userEmail: string;
}

export class UserOffer {
    id: number;

    description: string;

    price: Price;

    bookId: string;

    userEmail: string;
}

export class Price {
    id: number;
    priceType: PriceType;
    value: string;
}

export enum PriceType {
    Free,
    Paid
}

export class Contracts {
    id: number; 
    userDemand: UserDemand; 
    userEmail: string; 
    isAllowed: Boolean; 
}