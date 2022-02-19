function solve() {

    class Post {

        constructor(title, content) {

            this.title = title;

            this.content = content;

        }

        toString() {

            return `Post: ${this.title}\n` +
                `Content: ${this.content}`;

        }
    }


    class SocialMediaPost extends Post {

        constructor(title, content, likes, dislikes) {

            super(title, content);

            this.likes = likes;

            this.dislikes = dislikes;

        };

        comments = [];

        addComment(comment) {

            this.comments.push(comment);

        };

        toString() {
            let stringToReturn = super.toString() +
                `\nRating: ${this.likes - this.dislikes}`;

            return this.comments.length < 1 ?
                stringToReturn :
                stringToReturn + `\nComments:\n` + `${this.comments.map(x => ` * ${x}`).join('\n')}`;
        };
    }


    class BlogPost extends Post {

        constructor(title, content, views) {

            super(title, content);

            this.views = views;

        }

        view() {

            this.views++;

            return this;

        }

        toString() {

            return super.toString() +
                `\nViews: ${this.views}`;

        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
};


const classes = solve();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
