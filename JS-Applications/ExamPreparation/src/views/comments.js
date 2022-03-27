import { html } from '../../node_modules/lit-html/lit-html.js'
import * as commentsService from '../api/comments.js'

const commentTemplate = (comment) => html`
        <li class="comment">
            <p>Content: ${comment.comment}</p>
        </li>
`;

const commentsTempalte = (comments) => html`
<div class="details-comments">
    <h2>Comments:</h2>
    ${comments. length > 0 
    ? html`<ul>
        ${comments.map(x=> commentTemplate(x))}
        </ul>`
    : html`<p class="no-comment">No comments.</p>`}
</div>
`;

export async function commentsView(gameId) {
    const comments = await commentsService.getByGameId(gameId);
    return commentsTempalte(comments);
}