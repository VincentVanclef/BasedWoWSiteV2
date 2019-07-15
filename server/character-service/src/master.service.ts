export class MasterService {
    constructor() {}

    public respond(
        message: string,
        data?: any,
    ): { message: string; data: any } {
        return {
            message,
            data: data || {},
        };
    }
}
