export type AnswerDto = {
    id: number;
    questionId: number;
    content: string;
    selected: boolean;
}

export type QuestionDto =
    {
        id: number;
        content: string;
        type: string;
        singleChoice:number;
        answers: AnswerDto[];
    }

