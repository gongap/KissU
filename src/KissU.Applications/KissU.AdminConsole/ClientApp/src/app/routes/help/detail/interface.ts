export interface HelpItem {
  [key: string]: any;
  id?: string;
  title?: string;
  time?: string;
  content?: string;
  prev?: string;
  next?: string;
  recommended?: HelpRecommendedItem[];
}

export interface HelpRecommendedItem {
  [key: string]: any;
  id?: string;
  title?: string;
}
