import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';

import { PostEntity } from './post.entity';
import { MasterService } from '../master.service';

export class PostService extends MasterService {
    constructor(
        @InjectRepository(PostEntity)
        private readonly postRepo: Repository<PostEntity>,
    ) {
        super();
    }

    public async create(data) {
        const post = new PostEntity();

        post.title = data.title;
        post.type = data.type || null;
        post.content = data.content;
        post.createdAt = new Date().toISOString();

        await this.postRepo.save(post);

        return this.respond('Successfully created post.', post);
    }

    public async deleteOne(deleteOptions: { uuid?; id? }) {
        const post = await this.postRepo.delete(deleteOptions);

        return this.respond('Successfully deleted post.');
    }

    public async getOne(findOptions: { uuid?; id? }) {
        const post = await this.postRepo.findOne(findOptions);

        return this.respond('Successfully fetched post.', post);
    }

    public async getMany(options?: { order?: any; limit?: any; offset?: any }) {
        options.order = options.order ? options.order.toUpperCase() : 'DESC';
        options.limit = options.limit ? options.limit : 25;
        options.offset = options.offset ? options.offset : 0;

        const posts = await this.postRepo.find({
            order: {
                createdAt: options.order,
            },
            take: options.limit,
            skip: options.offset,
        });

        return this.respond('Successfully fetched posts.', posts);
    }
}
