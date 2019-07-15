import {
    Controller,
    Post,
    Body,
    Get,
    Param,
    Query,
    Delete,
} from '@nestjs/common';

import { PostDto } from './dto/post.dto';
import { PostService } from './post.service';

@Controller('posts')
export class PostController {
    constructor(private postService: PostService) {}

    @Post()
    public create(@Body() body: PostDto) {
        return this.postService.create(body);
    }

    @Delete(':uuid')
    public deleteOne(@Param('uuid') uuid: string) {
        return this.postService.deleteOne({
            uuid,
        });
    }

    @Get(':uuid')
    public getOne(@Param('uuid') uuid: string) {
        return this.postService.getOne({
            uuid,
        });
    }

    @Get()
    public getMany(
        @Query('order') order: string,
        @Query('limit') limit: number,
        @Query('offset') offset: number,
    ) {
        return this.postService.getMany({
            order,
            limit,
            offset,
        });
    }
}
