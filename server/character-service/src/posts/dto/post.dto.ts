import { IsNotEmpty, Allow, IsString } from 'class-validator';

export class PostDto {
    @IsString()
    @IsNotEmpty()
    public readonly title: string;

    @IsString()
    public readonly content: string;

    @Allow()
    public readonly type: string;
}
