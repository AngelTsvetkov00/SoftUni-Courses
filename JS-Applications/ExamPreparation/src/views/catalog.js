import { html } from '../../node_modules/lit-html/lit-html.js'
import * as gamesService from '../api/games.js'

const gameTemplate = (game) => html`
<div class="allGames">
    <div class="allGames-info">
        <img src="${game.imageUrl}">
        <h6>${game.category}</h6>
        <h2>${game.title}</h2>
        <a href="/details/${game._id}" class="details-button">Details</a>
    </div>
</div>
`;

const catalogTemplate = (games) => html`
<!-- Catalogue -->
<section id="catalog-page">
    <h1>All Games</h1>
    
    ${games.length > 0
        ? games.map(x=> gameTemplate(x))
        : html`<h3 class="no-articles">No articles yet</h3>
    `}
    
</section>
`;

export async function catalogView(ctx) {
    const games = await gamesService.getAll();
    ctx.render(catalogTemplate(games));
}