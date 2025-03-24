export interface Provider {
    providerName: string;
    price: string;
    created: string;
    lastModified: string;
}

export interface Movie {
    id: string;
    title: string;
    year: string;
    rated: string;
    released: string;
    runtime: string;
    genre: string;
    director: string;
    writer: string;
    actors: string;
    plot: string;
    language: string;
    country: string;
    awards: string;
    poster: string;
    metascore: string;
    rating: string;
    votes: string;
    type: string;
    providers: Provider[]
}

export const getMovies = async (): Promise<Movie[]> => {
    const response = await fetch("http://localhost:4200/api/movies");
    if (response.ok) {
        return response.json();
    }

    return Promise.reject('Error retrieving movies');
} 

/*
[
    {
       "id":"dd51ff00-8f13-4a43-8bb9-ecfbecf2cf8d",
       "title":"Star Wars: Episode IV - A New Hope",
       "year":"1977",
       "rated":"PG",
       "released":"25 May 1977",
       "runtime":"121 min",
       "genre":"Action, Adventure, Fantasy",
       "director":"George Lucas",
       "writer":"George Lucas",
       "actors":"Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing",
       "plot":"Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a wookiee and two droids to save the galaxy from the Empire's world-destroying battle-station, while also attempting to rescue Princess Leia from the evil Darth Vader.",
       "language":"English",
       "country":"USA",
       "awards":null,
       "poster":"https://m.media-amazon.com/images/M/MV5BOTIyMDY2NGQtOGJjNi00OTk4LWFhMDgtYmE3M2NiYzM0YTVmXkEyXkFqcGdeQXVyNTU1NTfwOTk@._V1_SX300.jpg",
       "metascore":"92",
       "rating":"8.7",
       "votes":"915,459",
       "type":"movie",
       "providers":[
          {
             "providerName":"FilmWorld",
             "price":"29.5",
             "created":"2025-03-23T13:37:15.9868055+00:00",
             "lastModified":"2025-03-23T13:37:15.9868055+00:00"
          },
          {
             "providerName":"CinemaWorld",
             "price":"123.5",
             "created":"2025-03-23T13:37:21.9426158+00:00",
             "lastModified":"2025-03-23T13:37:21.9426158+00:00"
          }
       ],
       "created":"2025-03-23T13:37:15.9867629+00:00",
       "lastModified":"2025-03-23T13:37:15.9867629+00:00"
    },
    {
       "id":"2ec7d869-310a-40b7-acae-d58f5545320c",
       "title":"Star Wars: Episode V - The Empire Strikes Back",
       "year":"1980",
       "rated":"PG",
       "released":"20 Jun 1980",
       "runtime":"124 min",
       "genre":"Action, Adventure, Fantasy",
       "director":"Irvin Kershner",
       "writer":"Leigh Brackett (screenplay), Lawrence Kasdan (screenplay), George Lucas (story by)",
       "actors":"Mark Hamill, Harrison Ford, Carrie Fisher, Billy Dee Williams",
       "plot":"After the Rebel base on the icy planet Hoth is taken over by the Empire, Han, Leia, Chewbacca, and C-3PO flee across the galaxy from the Empire. Luke travels to the forgotten planet of Dagobah to receive training from the Jedi master Yoda, while Vader endlessly pursues him.",
       "language":"English",
       "country":"USA",
       "awards":null,
       "poster":"https://m.media-amazon.com/images/M/MV5BMjE2MzQwMTgxN15BMl5BanBnXkFtZTfwMDQzNjk2OQ@@._V1_SX300.jpg",
       "metascore":"80",
       "rating":"8.8",
       "votes":"842,451",
       "type":"movie",
       "providers":[
          {
             "providerName":"FilmWorld",
             "price":"1295.0",
             "created":"2025-03-23T13:37:16.321633+00:00",
             "lastModified":"2025-03-23T13:37:16.321633+00:00"
          },
          {
             "providerName":"CinemaWorld",
             "price":"13.5",
             "created":"2025-03-23T13:37:25.4853136+00:00",
             "lastModified":"2025-03-23T13:37:25.4853136+00:00"
          }
       ],
       "created":"2025-03-23T13:37:16.3216324+00:00",
       "lastModified":"2025-03-23T13:37:16.3216324+00:00"
    },
    {
       "id":"ad61a75d-14a1-4011-911c-22df3042ced2",
       "title":"Star Wars: Episode VI - Return of the Jedi",
       "year":"1983",
       "rated":"PG",
       "released":"25 May 1983",
       "runtime":"131 min",
       "genre":"Action, Adventure, Fantasy",
       "director":"Richard Marquand",
       "writer":"Lawrence Kasdan (screenplay), George Lucas (screenplay), George Lucas (story by)",
       "actors":"Mark Hamill, Harrison Ford, Carrie Fisher, Billy Dee Williams",
       "plot":"After rescuing Han Solo from the palace of Jabba the Hutt, the rebels attempt to destroy the second Death Star, while Luke struggles to make Vader return from the dark side of the Force.",
       "language":"English",
       "country":"USA",
       "awards":null,
       "poster":"https://m.media-amazon.com/images/M/MV5BMTQ0MzI1NjYwOF5BMl5BanBnXkFtZTgwODU3NDU2MTE@._V1._CR93,97,1209,1861_SX89_AL_.jpg_V1_SX300.jpg",
       "metascore":"53",
       "rating":"8.4",
       "votes":"686,479",
       "type":"movie",
       "providers":[
          {
             "providerName":"FilmWorld",
             "price":"69.5",
             "created":"2025-03-23T13:37:17.2493371+00:00",
             "lastModified":"2025-03-23T13:37:17.2493371+00:00"
          },
          {
             "providerName":"CinemaWorld",
             "price":"253.5",
             "created":"2025-03-23T13:37:26.3304066+00:00",
             "lastModified":"2025-03-23T13:37:26.3304066+00:00"
          }
       ],
       "created":"2025-03-23T13:37:17.2493359+00:00",
       "lastModified":"2025-03-23T13:37:17.2493359+00:00"
    },
    {
       "id":"17c53efc-5d40-4f04-bd9a-b37bcc811bd6",
       "title":"Star Wars: Episode I - The Phantom Menace",
       "year":"1999",
       "rated":"PG",
       "released":"19 May 1999",
       "runtime":"136 min",
       "genre":"Action, Adventure, Fantasy",
       "director":"George Lucas",
       "writer":"George Lucas",
       "actors":"Liam Neeson, Ewan McGregor, Natalie Portman, Jake Lloyd",
       "plot":"Two Jedi Knights escape a hostile blockade to find allies and come across a young boy who may bring balance to the Force, but the long dormant Sith resurface to reclaim their old glory.",
       "language":"English",
       "country":"USA",
       "awards":null,
       "poster":"https://m.media-amazon.com/images/M/MV5BMTQ4NjEwNDA2Nl5BMl5BanBnXkFtZTfwNDUyNDQzNw@@._V1_SX300.jpg",
       "metascore":"51",
       "rating":"6.5",
       "votes":"537,242",
       "type":"movie",
       "providers":[
          {
             "providerName":"FilmWorld",
             "price":"900.5",
             "created":"2025-03-23T13:37:18.1334945+00:00",
             "lastModified":"2025-03-23T13:37:18.1334945+00:00"
          }
       ],
       "created":"2025-03-23T13:37:18.1334941+00:00",
       "lastModified":"2025-03-23T13:37:18.1334941+00:00"
    },
    {
       "id":"e76e46bc-c997-4a90-adec-ff05b13b52f6",
       "title":"Star Wars: Episode III - Revenge of the Sith",
       "year":"2005",
       "rated":"PG-13",
       "released":"19 May 2005",
       "runtime":"140 min",
       "genre":"Action, Adventure, Fantasy",
       "director":"George Lucas",
       "writer":"George Lucas",
       "actors":"Ewan McGregor, Natalie Portman, Hayden Christensen, Ian McDiarmid",
       "plot":"During the near end of the clone wars, Darth Sidious has revealed himself and is ready to execute the last part of his plan to rule the Galaxy. Sidious is ready for his new apprentice, Lord...",
       "language":"English",
       "country":"USA",
       "awards":null,
       "poster":"https://m.media-amazon.com/images/M/MV5BNTc4MTc3NTQ5OF5BMl5BanBnXkFtZTfwOTg0NjI4NA@@._V1_SX300.jpg",
       "metascore":"68",
       "rating":"7.6",
       "votes":"522,705",
       "type":"movie",
       "providers":[
          {
             "providerName":"FilmWorld",
             "price":"129.9",
             "created":"2025-03-23T13:37:22.1451739+00:00",
             "lastModified":"2025-03-23T13:37:22.1451739+00:00"
          }
       ],
       "created":"2025-03-23T13:37:22.1451735+00:00",
       "lastModified":"2025-03-23T13:37:22.1451735+00:00"
    },
    {
       "id":"89225448-d753-4bf8-83d0-5a90f770a0d6",
       "title":"Star Wars: Episode II - Attack of the Clones",
       "year":"2002",
       "rated":"PG",
       "released":"16 May 2002",
       "runtime":"142 min",
       "genre":"Action, Adventure, Fantasy",
       "director":"George Lucas",
       "writer":"George Lucas (screenplay), Jonathan Hales (screenplay), George Lucas (story by)",
       "actors":"Ewan McGregor, Natalie Portman, Hayden Christensen, Christopher Lee",
       "plot":"Ten years after initially meeting, Anakin Skywalker shares a forbidden romance with Padmé, while Obi-Wan investigates an assassination attempt on the Senator and discovers a secret clone army crafted for the Jedi.",
       "language":"English",
       "country":"USA",
       "awards":null,
       "poster":"https://m.media-amazon.com/images/M/MV5BNDRkYzA4OGYtOTBjYy00YzFiLThhYmYtMWUzMDBmMmZkM2M3XkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_SX300.jpg",
       "metascore":"54",
       "rating":"6.7",
       "votes":"469,134",
       "type":"movie",
       "providers":[
          {
             "providerName":"FilmWorld",
             "price":"1249.5",
             "created":"2025-03-23T13:37:22.8866851+00:00",
             "lastModified":"2025-03-23T13:37:22.8866851+00:00"
          }
       ],
       "created":"2025-03-23T13:37:22.8866846+00:00",
       "lastModified":"2025-03-23T13:37:22.8866846+00:00"
    }
 ]
    */